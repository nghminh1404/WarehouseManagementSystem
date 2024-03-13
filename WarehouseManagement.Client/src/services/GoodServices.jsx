import axios from "./axios"

const fetchGoodsWithFilter = (page, categoryId, supplierId, keyword) => {
    return axios.get(`api/goods/get-goods??page=${page}${categoryId ? `categoryId=${categoryId}` : ''}${supplierId ? `supplierId=${supplierId}` : ''}${keyword ? `&keyword=${keyword}` : ''}`);
}

export { fetchGoodsWithFilter }
