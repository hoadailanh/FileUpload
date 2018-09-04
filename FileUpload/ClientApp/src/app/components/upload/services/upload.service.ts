import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient} from '@angular/common/http';
import { UploadResult } from '../models/upload-result';

@Injectable()
export class UploadService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  uploadCsv(file: File): Observable<UploadResult> {
    const formData = new FormData();
    formData.append(file.name, file);
    return this.http.post<UploadResult>(this.baseUrl + "api/file/uploadcsv", formData);
  }
}
