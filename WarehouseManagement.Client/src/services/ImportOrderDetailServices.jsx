import axios from "./axios"

const createNewImportOrderDetail = (importId, costPrice, goodsId, quantity) => {
    return axios.post(`api/ImportOrderDetail/add-order-detail`, { importId, costPrice, goodsId, quantity })
}

const getImportOrderDetailByImportId = (importId) => {
    return axios.get(`api/ImportOrderDetail/get-import-order-details?oid=${importId}`)
}

export { createNewImportOrderDetail, getImportOrderDetailByImportId }