export interface GetSetRsModel {
    name: string;
    setId: string;
    imageUrl: string;
    thumbnailUrl: string;
    weight: string;
    dim_x: string;
    dim_y: string;
    dim_z: string;
    yearReleased: number;
    isObsolete: boolean;
}

export interface SetModel {
    setName: string;
    setId: string;
    setCondition: string;
}