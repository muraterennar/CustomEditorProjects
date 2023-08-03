import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { BlogDetailModel, BlogModel, BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent implements OnInit {

  blogEmitter = new EventEmitter<any>();

  constructor(
    private blogService: BlogService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  blogs: BlogDetailModel[];
  image: string;


  /* #region CRUD Operations */
  getAll() {
    this.blogService.getAll().subscribe((response) => {
      this.blogs = response
      console.log(this.blogs);
    }, (errorResponse: HttpErrorResponse) => {
      console.log(`Hata -> ${errorResponse.status} __ ${errorResponse.message}`);
    });
  }
  /* #endregion */


  // Go to blog details
  blogDetail(blog: BlogDetailModel) {
    // let bTitle: string;
    // for (let i = 0; i <= blog.blogTitle.length; i++) {
    //   blog.blogTitle = blog.blogTitle.replace(" ", "").toLowerCase();
    //   bTitle = blog.blogTitle;
    // }

    this.router.navigate([`blogdetails/${blog.blogTitle}`]);
  }

  imageSrc(categoryName: string) {
    if (categoryName == CategoryName.desing) {
      return this.image = ImageUrls.desing
    }
    else if (categoryName == CategoryName.backend) {
      return this.image = ImageUrls.backend
    }
    else if (categoryName == CategoryName.frontend) {
      return this.image = ImageUrls.frontend
    }

    return this.image = ImageUrls.default
  }

}

export enum CategoryName {
  desing = "Tasarım",
  frontend = "Frontend",
  backend = "Backend",
}

export enum ImageUrls {
  backend = "https://localhost:7124/project-img/backend.jpg",
  frontend = "https://localhost:7124/project-img/frontend.jpg",
  desing = "https://localhost:7124/project-img/desing.jpg",
  default = "https://dummyimage.com/200x200/#25252/fff"
}


