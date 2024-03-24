import axios from "./axios"

const createNewImportOrderDetail = (importId, costPrice, goodsId, quantity) => {
    return axios.post(`api/ImportOrderDetail/add-order-detail`, { importId, costPrice, goodsId, quantity })
}

export { createNewImportOrderDetail }