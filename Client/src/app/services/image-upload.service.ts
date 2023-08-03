import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, finalize, tap } from 'rxjs';
import { CustomHttpClientService } from './custom-http-client.service';
import { AngularFireStorage, AngularFireUploadTask } from '@angular/fire/compat/storage';

@Injectable({
  providedIn: 'root'
})
export class ImageUploadService {

  task: AngularFireUploadTask;
  percentage: Observable<number>;
  snapshot: Observable<any>;
  downloadUrl: string;

  constructor(
    public customHttp: CustomHttpClientService,
    private storage: AngularFireStorage,
  ) { }

  getFiles() {
    this.customHttp.get({
      controller: 'blogimages'
    }).subscribe((response) => {
      console.log(response);
    }, (errorResponse: HttpErrorResponse) => {
      console.log(errorResponse);
    })
  }

  fileUpload(file: File, fileName: string) {
    const fileData: FormData = new FormData();
    fileData.append(fileName, file);

    return this.customHttp.post({
      controller: "blogimages",
      action: `upload/${fileName}`,
      headers: new HttpHeaders({ "responseType": "blob" })
    }, fileData);
  }

  addDatabase(image: Partial<ImageModel>) {
    return this.customHttp.post({
      controller: "BlogImages",
      action: "AddDatabase"
    }, image);
  }


  fileUploadFirebase(file: File, uniqueSafeName: string) {
    const path: string = `customEditorImage/${uniqueSafeName}`;
    const ref = this.storage.ref(path);


    let imagetag = document.getElementById('fileImage') as HTMLImageElement;
    let imageUrl = `https://firebasestorage.googleapis.com/v0/b/file-upload-firebase-d3899.appspot.com/o/customEditorImage%2F${uniqueSafeName}?alt=media&token=4631e44b-c24a-497d-81a9-7778697b3712`
    // Upload
    this.task = this.storage.upload(path, file);
    this.percentage = this.task.percentageChanges();
    this.snapshot = this.task.snapshotChanges().pipe(
      tap(console.log),

      finalize(async () => {
        this.downloadUrl = await ref.getDownloadURL().toPromise();
      }),
    )

    setTimeout(() => {
      this.addDatabase({
        imageName: uniqueSafeName,
        imageUrl: this.downloadUrl ? this.downloadUrl : imageUrl
      }).subscribe((response) => {
        console.log(response);
        alert("BEKLEYİN");
      }, (errorResponse: HttpErrorResponse) => {
        console.log(errorResponse)
      });
    }, 2500)
  }

  getFileByImageName(imageName: string) {
    return this.customHttp.get<ImageModel>({
      controller: "blogimages",
      action: `GetByImagePath/${imageName}`,
    });
  }

  imageReader(image: HTMLImageElement, fileInput: HTMLInputElement) {
    var reader: FileReader = new FileReader();
    reader.onload = () => {
      image.src = reader.result as string;
    }

    if (fileInput) {
      let file: File = fileInput.files[0];
      reader.readAsDataURL(file);
    }
    else {
      image.src = '';
    }
  }
}

export class ImageModel {
  id: number;
  imageName: string;
  imageUrl: string;
}
