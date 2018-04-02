import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';

import { RoboService } from './components/service/robo.service';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        FormsModule,
        HttpModule,
        ServerModule,
        AppModuleShared,
        JsonpModule
    ],
    providers: [RoboService]
})
export class AppModule {
}
