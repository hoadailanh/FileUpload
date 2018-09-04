import { Component} from '@angular/core';
import { UploadService } from './services/upload.service'
import { UploadResult } from './models/upload-result'

@Component({
  selector: 'upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent {
  public result: UploadResult | undefined;
  public errorMessage: any;
  public uploading: boolean = false;
  public pageNumber: number = 0;
  public pageSize: number = 5;
  public pageRecords: string[][];

  constructor(private uploadService: UploadService) { }

  public upload(files: any): void {
    if (files.length === 0)
      return;

    this.errorMessage = "";
    this.uploading = true;
    this.uploadService.uploadCsv(files[0]).subscribe(
      result => {
        this.result = result;
        this.setPage(0);
      },
      error => this.errorMessage = error.error,
      () => this.uploading = false
    );
  }

  public setPage(pageNumber: number): void {
    this.pageNumber = pageNumber;
    let startPos: number = this.pageNumber * this.pageSize;
    let endPos: number = startPos + this.pageSize;
    this.pageRecords = this.result.rows.slice(startPos, endPos);
  }

  public loadPage(page: number): void {
    this.setPage(page - 1);
  }

  public isMoneyFormat(input: string): boolean {
    
    let result = /^"(0|([1-9](\d*|\d{0,2}(,\d{3})*)))?(\.\d{1,2})?"$/.test(input);
    return result;
    //return /^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:(\.|,)\d+)?$/.test(input) && (input.indexOf(",") > -1 || input.indexOf(".") > -1);
  }

  public getMoney(input: string): string {
    if (!input)
      return input;
    let result = input.replace(/"|,/g, '');
    return result;
  }
}
