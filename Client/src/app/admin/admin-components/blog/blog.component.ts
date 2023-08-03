import { Component, OnInit } from '@angular/core';
import { BlogCategory, BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  constructor(
    private blogService: BlogService
  ) { }

  ngOnInit(): void {
    this.getBlogCategory();
  }

  blogCat: BlogCategory[];

  getBlogCategory() {
    return this.blogService.getAllByCategory().subscribe((response) => {
      this.blogCat = response;
      console.log(this.blogCat);
    });
  }

}
