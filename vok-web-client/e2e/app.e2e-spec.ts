import { VokWebClientPage } from './app.po';

describe('vok-web-client App', function() {
  let page: VokWebClientPage;

  beforeEach(() => {
    page = new VokWebClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
