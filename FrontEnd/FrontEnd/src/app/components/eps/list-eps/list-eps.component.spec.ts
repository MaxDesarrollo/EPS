import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListEpsComponent } from './list-eps.component';

describe('ListEpsComponent', () => {
  let component: ListEpsComponent;
  let fixture: ComponentFixture<ListEpsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListEpsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListEpsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
