import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';


@NgModule({
  declarations: [],
  providers: [provideHttpClient(withInterceptorsFromDi())],
  imports: [CommonModule],
  bootstrap: []
})
export class AppModule { }
