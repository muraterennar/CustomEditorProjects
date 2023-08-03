import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogDetailModel, BlogModel, BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-blog-details',
  templateUrl: './blog-details.component.html',
  styleUrls: ['./blog-details.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class BlogDetailsComponent implements OnInit {


  constructor(
    private blogService: BlogService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  blog?: BlogDetailModel;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((paramMap) => {
      console.log(paramMap['blogTitle']);
      this.getByBlogTitle(paramMap['blogTitle']);
    });
  }

  getByBlogTitle(blogTitle: string) {
    this.blogService.getByBlogTitle(blogTitle).subscribe((response) => {
      return this.blog = response;
    }, (errorResponse: HttpErrorResponse) => {
      console.log(`Error -> ${errorResponse.status} __ ${errorResponse.message}`);
    });
  }

  deleteBlog(id: number) {
    this.blogService.deleteBlog(id).subscribe((response) => {
      console.log(response);
      alert("Deleted");
      this.router.navigate(['']);
    }, (errorResponse: HttpErrorResponse) => {
      console.log(errorResponse);
    })
  }

}
