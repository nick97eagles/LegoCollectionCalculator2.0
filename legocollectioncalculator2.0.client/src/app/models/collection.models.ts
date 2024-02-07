export interface CreateThemeRsModel {
    themeID: number;
    name: string;
    description: string;
}

export interface Theme {
    themeID: number
    collectionID: number;
    name: string;
    description: string;
}

export interface GetThemesRsModel {
    themes: Theme[];
}