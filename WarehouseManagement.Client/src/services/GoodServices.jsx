import axios from "./axios"

const fetchGoodsWithFilter = (page, keyword) => {
    return axios.get(`api/goods/get-goods??page=${page}${keyword ? `&keyword=${keyword}` : ''}`);
}

export { fetchGoodsWithFilter }
