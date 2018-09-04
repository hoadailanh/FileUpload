import { AppPage } from './app.po';

describe('App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display upload file', () => {
    page.navigateTo();
    expect(page.getMainHeading()).toEqual('Choose file');
  });
});
