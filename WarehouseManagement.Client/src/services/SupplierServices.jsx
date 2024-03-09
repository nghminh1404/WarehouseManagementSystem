import axios from "./axios"

const fetchAllSuppliers = (page) => {
    return axios.get(`api/supplier/get-supplier?page=${page}`);
}

const fetchSuppliersWithKeyword = (page, keyword) => {
    return axios.get(`api/supplier/get-supplier?page=${page}&keyword=${keyword}`)
}

const createNewSupplier = (supplierName, supplierPhone, statusId, supplierEmail, note) => {
    return axios.post(`api/supplier/add-supplier`, { supplierName, supplierPhone, statusId, supplierEmail, note })
}

export { fetchAllSuppliers, fetchSuppliersWithKeyword, createNewSupplier }
