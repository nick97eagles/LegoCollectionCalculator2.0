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

export interface AddSetsRqModel {
    themeID: number;
    sets: AddSetModel[];
}

export interface AddSetModel {
    identificationNum: string;
    name: string;
    condition: string;
}

export interface GetSetModel {
    setID: number;
    themeID: number
    identificationNum: string;
    name: string;
    condition: string;
}

export interface GetSetsRsModel {
    sets: GetSetModel[];
}