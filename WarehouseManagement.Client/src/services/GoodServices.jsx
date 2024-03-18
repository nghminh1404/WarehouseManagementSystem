import axios from "./axios"

const fetchGoodsWithFilter = (page, storageId, categoryId, supplierId, sortPrice, keyword) => {
    return axios.get(`api/goods/get-goods?page=${page}${storageId ? `&storageId=${storageId}` : ''}${categoryId ? `&categoryId=${categoryId}` : ''}
    ${supplierId ? `&supplierId=${supplierId}` : ''}${sortPrice ? `&sortPrice=${sortPrice}` : ''}
    ${keyword ? `&keyword=${keyword}` : ''}`);
}

export { fetchGoodsWithFilter }
