import { TestBed, async } from '@angular/core/testing';
import { UploadComponent } from './upload.component';
import { UploadService } from './services/upload.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { UploadResult } from './models/upload-result';

const uploadResult: UploadResult = {
  headers: ["header 1", "header 2"],
  rows: [
    ["row 1 - value 1", "row 1 - value 2"],
    ["row 2 - value 1", "row 2 - value 2"],
    ["row 3 - value 1", "row 3 - value 2"],
    ["row 4 - value 1", "row 4 - value 2"],
    ["row 5 - value 1", "row 5 - value 2"],
    ["row 6 - value 1", "row 6 - value 2"],
    ["row 7 - value 1", "row 7 - value 2"],
    ["row 8 - value 1", "row 8 - value 2"],
    ["row 9 - value 1", "row 9 - value 2"],
    ["row 10 - value 1", "row 10 - value 2"],
    ["row 11 - value 1", "row 11 - value 2"]
  ]
};

class MockUploadService {
  public uploadCsv(file: File): Observable<UploadResult> {
    return Observable.of(uploadResult);
  }
}

describe('Component: Upload', () => {
  let component: UploadComponent;
  let service: MockUploadService;
  let spy: any;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [NgbModule.forRoot()],
      declarations: [
        UploadComponent
      ],
      providers: [
        { provide: UploadService, useClass: MockUploadService }
      ]
    });
    component = TestBed.createComponent(UploadComponent).componentInstance;
    service = TestBed.get(UploadService);
    component.upload(new File([], "dummy"));
  });

  it('it should return upload result', () => {
    expect(component.result).toBe(uploadResult);
  });

  it('it should have the correct page records', () => {
    component.setPage(0);
    let pageRecords = uploadResult.rows.slice(0, component.pageSize);
    expect(component.pageRecords).toEqual(pageRecords);
  });

  it('it should have the correct page records', () => {
    component.setPage(2);
    expect(component.pageRecords).toEqual([["row 11 - value 1", "row 11 - value 2"]]);
  });

  it('it should have the correct page records', () => {
    component.setPage(1);
    let pageRecords = uploadResult.rows.slice(1 * component.pageSize, 1 * component.pageSize + component.pageSize);
    expect(component.pageRecords).toEqual(pageRecords);
  });

  it('it should convert "123,111.00" to 123111.00', () => {
    expect(component.getMoney('"123,111.00"')).toEqual("123111.00");
  });

  it('it should convert "\"\"" to ""', () => {
    expect(component.getMoney('""')).toEqual("");
  });

  it('it should return null for null input', () => {
    expect(component.getMoney(null)).toEqual(null);
  });

  it('"" should be money format', () => {
    expect(component.isMoneyFormat('""')).toBeTruthy();
  });

  it('"123,111.00" should be money format', () => {
    expect(component.isMoneyFormat('"123,111.00"')).toBeTruthy();
  });

  it('"123111.00" should be money format', () => {
    expect(component.isMoneyFormat('"123,111.00"')).toBeTruthy();
  });

  it('"1" should be money format', () => {
    expect(component.isMoneyFormat('"123,111.00"')).toBeTruthy();
  });

  it('"0.1" should be money format', () => {
    expect(component.isMoneyFormat('"123,111.00"')).toBeTruthy();
  });


  it('"abc,111.000" should not be money format', () => {
    expect(component.isMoneyFormat('"123,111.000"')).toBeFalsy();
  });

  it('"11a1" should not be money format', () => {
    expect(component.isMoneyFormat('"123,111.000"')).toBeFalsy();
  });

  it('"1111,11.00" should not be money format', () => {
    expect(component.isMoneyFormat('"123,111.000"')).toBeFalsy();
  });

  it('"123,111.000" should not be money', () => {
    expect(component.isMoneyFormat('"123,111.000"')).toBeFalsy();
  });

});
