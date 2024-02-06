export interface CreateUserRsModel {
    userId: number;
    collectionId: number;
    userName: string;
    userEmail: string;
    resultMessage: string;
}

export interface LoginRsModel {
    userId: number;
    userName: string;
    userEmail: string;
    collectionId: number;
    userRole: string;
    resultMessage: string;
}

export interface UserInfo {
    userId: number;
    userName: string;
    userEmail: string;
    userRole: string;
    collectionId: number;
}