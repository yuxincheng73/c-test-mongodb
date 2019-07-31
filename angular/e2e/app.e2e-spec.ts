import { TCCTemplatePage } from './app.po';

describe('TCC App', function() {
  let page: TCCTemplatePage;

  beforeEach(() => {
    page = new TCCTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
