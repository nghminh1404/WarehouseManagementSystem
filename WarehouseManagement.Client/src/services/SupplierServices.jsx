import axios from "./axios"

const fetchAllSuppliers = (page) => {
    return axios.get(`api/supplier/get-supplier?page=${page}`);
}

const fetchSuppliersWithKeyword = (page, keyword) => {
    return axios.get(`api/supplier/get-supplier?page=${page}${keyword ? `&keyword=${keyword}` : ``}`)
}

const createNewSupplier = (supplierName, supplierPhone, statusId, supplierEmail, note) => {
    return axios.post(`api/supplier/add-supplier`, { supplierName, supplierPhone, statusId, supplierEmail, note })
}

const updateSupplier = (supplierId, supplierName, supplierPhone, statusId, supplierEmail, note) => {
    return axios.put(`api/supplier/update-supplier`, { supplierId, supplierName, supplierPhone, statusId, supplierEmail, note })
}

const updateStatusSupplier = (supplierId) => {
    return axios.put(`api/supplier/update-supplier-status?id=${supplierId}`);
}

export { fetchAllSuppliers, fetchSuppliersWithKeyword, createNewSupplier, updateSupplier, updateStatusSupplier }
