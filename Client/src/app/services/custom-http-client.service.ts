import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomHttpClientService implements OnInit {

  constructor(
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
  }

  baseUrl: string = "https://localhost:7023/api";
  // baseUrl: string = "https://customeditorserver.muraterennar.net/api";

  private url(requestParameters: Partial<RequestParameters>): string {
    return `${requestParameters.baseUrl ? requestParameters.baseUrl : this.baseUrl}/${requestParameters.controller}${requestParameters.action ? `/${requestParameters.action}` : ''}`;
  }

  get<T>(requestParameters: Partial<RequestParameters>, id?: number): Observable<T> {
    let url: string;

    if (requestParameters.fullEndPoint) {
      url = requestParameters.fullEndPoint;
    } else {
      // url = `${this.url(requestParameters)}${id ? `/${id}` : ''}`;
      url = `${this.url(requestParameters)}${id ? `?id=${id}` : ''}`;
    }

    return this.httpClient.get<T>(url, { headers: requestParameters.headers });
  }

  post<T>(requestParameters: RequestParameters, body: Partial<T>): Observable<T> {
    let url: string;
    if (requestParameters.fullEndPoint) {
      url = requestParameters.fullEndPoint
    }
    else {
      url = `${this.url(requestParameters)}`
      // url = `${this.url(requestParameters)}${requestParameters.queryString ? `?${requestParameters.queryString}` : ""}`
    }

    return this.httpClient.post<T>(url, body);
  }

  put<T>(requestParameters: RequestParameters, body: Partial<T>): Observable<T> {
    let url: string;
    if (requestParameters.fullEndPoint) {
      url = requestParameters.fullEndPoint
    }
    else {
      url = `${this.url(requestParameters)}`
    }

    return this.httpClient.put<T>(url, body, { headers: requestParameters.headers });
  }

  patch<T>(requestParameters: RequestParameters, body: Partial<T>): Observable<T> {
    let url: string;
    if (requestParameters.fullEndPoint) {
      url = requestParameters.fullEndPoint
    }
    else {
      url = `${this.url(requestParameters)}`
    }

    return this.httpClient.patch<T>(url, body, { headers: requestParameters.headers });
  }

  delete<T>(requestParameters: RequestParameters, id: number) {
    let url: string;
    if (requestParameters.fullEndPoint) {
      url = requestParameters.fullEndPoint;
    }
    else {
      url = `${this.url(requestParameters)}/` + id;
    }

    return this.httpClient.delete<T>(url, { headers: requestParameters.headers });
  }
}

export class RequestParameters {
  controller?: string | ControllerTypes;
  action?: string;
  id?: number;
  headers?: HttpHeaders;
  baseUrl?: string;
  fullEndPoint?: string;
  queryString?: string;
}

export enum ControllerTypes {
  images = "images",
  blogs = "blogs"
}

