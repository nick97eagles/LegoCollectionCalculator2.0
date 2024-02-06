import { Injectable } from "@angular/core";
import { LocalStorageService } from "./local-storage.service";
import { UserInfo } from "../models/user.models";

@Injectable({
    providedIn: 'root'
})
export class UserDataService {
    
    constructor(private _localStorageService: LocalStorageService) { }

    public setUserData(userData: UserInfo): void {
        this._localStorageService.saveData('userInfo', JSON.stringify(userData));
    }

    public getUserData(): UserInfo | null {
        var userInfo = this._localStorageService.getData('userInfo');
        
        if (userInfo === null) {
            return null;
        }
       
        return JSON.parse(userInfo) as UserInfo;
    }

}