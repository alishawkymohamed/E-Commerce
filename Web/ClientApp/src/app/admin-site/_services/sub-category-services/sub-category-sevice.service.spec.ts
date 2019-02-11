import { TestBed } from '@angular/core/testing';
import { SubCategoryService } from './sub-category-service.service';

describe('SubCategorySeriveService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SubCategoryService = TestBed.get(SubCategoryService);
    expect(service).toBeTruthy();
  });
});
