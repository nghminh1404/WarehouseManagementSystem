import axios from "./axios"

const fetchGoodsWithFilter = (page, storageId, categoryId, supplierId, sortPrice, keyword) => {
    return axios.get(`api/goods/get-goods?page=${page}${storageId ? `&storageId=${storageId}` : ''}${categoryId ? `&categoryId=${categoryId}` : ''}
    ${supplierId ? `&supplierId=${supplierId}` : ''}${sortPrice ? `&sortPrice=${sortPrice}` : ''}
    ${keyword ? `&keyword=${keyword}` : ''}`);
}

const fetchAllGoods = () => {
    return axios.get(`api/goods/get-all-goods`);
}

const fetchGoodsWithStorageAndSupplier = (storageId, supplierId) => {
    return axios.get(`api/goods/get-goods-with-storage-supplier?storageId=${storageId}&supplierId=${supplierId}`)
}

export { fetchGoodsWithFilter, fetchAllGoods, fetchGoodsWithStorageAndSupplier }
