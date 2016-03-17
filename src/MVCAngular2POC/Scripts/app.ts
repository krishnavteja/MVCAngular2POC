/// <reference path="../node_modules/angular2/typings/browser.d.ts" />

import { bootstrap } from 'angular2/platform/browser';
import { Component, View } from 'angular2/core';



@Component({
    selector: "my-app"
})
@View({
    template: `
{{message}}
<br/><input [(ngModel)]="message"/>
`
})
class AppComponent
{
    message: string = "Hello World!";
}

bootstrap(AppComponent);