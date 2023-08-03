import { EventEmitter, Injectable } from '@angular/core';
import { CustomHttpClientService } from './custom-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  blogEmitter = new EventEmitter<BlogDetailModel>();

  constructor(
    public customHttpService: CustomHttpClientService
  ) { }

  getAll() {
    return this.customHttpService.get<BlogDetailModel[]>({
      controller: "blogs",
      action: "getllbtdto"
    });
  }

  getByBlogTitle(blogTitle: string) {
    return this.customHttpService.get<BlogDetailModel>({
      controller: "blogs",
      action: `getbyblogtitle/${blogTitle}`
    });


  }

  getbyid(id: number) {
    return this.customHttpService.get({
      controller: "blogs",
      action: "getbyid"
    }, id);
  }

  blogPost(data: Partial<BlogModel>) {
    return this.customHttpService.post<BlogModel>({
      controller: "Blogs",
      action: "add"
    }, {
      blogDescription: data.blogDescription,
      blogCategoryId: data.blogCategoryId,
      blogTitle: data.blogTitle
    });
  }

  deleteBlog(id: number) {
    return this.customHttpService.post({
      controller: "Blogs",
      action: `delete/${id}`
    }, id);
  }



  /* #region Blog Category Service */
  getByCategoryIdForCategoryName(id: number) {
    return this.customHttpService.get({
      controller: "BlogCategories",
      action: `getbyid/${id}`
    });
  }

  getAllByCategory() {
    return this.customHttpService.get<BlogCategory[]>({
      controller: "BlogCategories"
    });
  }

  /* #endregion */



}

export interface BlogModel {
  id: number;
  blogTitle: string;
  blogCategoryId: number;
  blogDescription: string;
}

export interface BlogCategory {
  id: number;
  categoryName: string;
}

export interface BlogDetailModel {
  id: number;
  blogTitle: string;
  categoryName: string;
  blogDescription: string;
}

export interface BlogCategoryService {
  id: number;
  categoryName: string;
}
