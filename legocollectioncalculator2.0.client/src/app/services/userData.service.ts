import { Injectable } from "@angular/core";
import { LocalStorageService } from "./local-storage.service";
import { UserInfo } from "../models/user.models";
import { Subject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class UserDataService {

    public isSignedInObserver: Subject<boolean> = new Subject<boolean>();
    public isSignedIn: boolean = false;
    
    constructor(private _localStorageService: LocalStorageService) {
        this.isSignedInObserver.subscribe(value => this.isSignedIn = value);

        var userInfo = this.getUserData();

        if (userInfo) {
            this.isSignedInObserver.next(true);
        }
    }

    public setUserData(userData: UserInfo): void {
        this._localStorageService.saveData('userInfo', JSON.stringify(userData));
        this.isSignedInObserver.next(true);
    }

    public getUserData(): UserInfo | null {
        var userInfo = this._localStorageService.getData('userInfo');
        
        if (userInfo === null) {
            return null;
        }
       
        return JSON.parse(userInfo) as UserInfo;
    }

    public clearUserData(): void {
        this.isSignedInObserver.next(false);
        this._localStorageService.clearData('userInfo');
    }

}