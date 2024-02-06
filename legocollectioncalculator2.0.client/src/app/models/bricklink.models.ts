export interface BrickLinkApiRsModel {

}

export interface SetModel {
    setName: string;
    setId: string;
    setCondition: string;
}

export interface SetApiRsModel {
    data: {
        category_id: number;
        dim_x: string;
        dim_y: string;
        dim_z: string;
        image_url: string;
        is_obsolete: boolean;
        name: string;
        no: string;
        thumbnail_url: string;
        type: string;
        weight: string;
        year_released: number;
    };
    meta: {
        description: string;
        message: string;
        code: number;
    }
}

export interface PriceGuideModel {
    avg_price: string;
    currency_code: string;
    item: {
        no: string;
        type: string;
    };
    max_price: string;
    min_price: string;
    new_or_used: string;
    price_detail: {
        quantity: number;
        unit_price: string;
        shipping_available: boolean;
        qunatity: number;
    }[];
    qty_avg_price: string;
    total_quantity: number;
    unit_quantity: number;
}