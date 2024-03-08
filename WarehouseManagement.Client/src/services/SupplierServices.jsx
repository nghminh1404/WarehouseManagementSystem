import axios from "./axios"

const fetchAllSuppliers = (page) => {
    return axios.get(`api/supplier/get-supplier?page=${page}`);
}

const fetchSuppliersWithKeyword = (page, keyword) => {
    return axios.get(`api/supplier/get-supplier?page=${page}&keyword=${keyword}`)
}

export { fetchAllSuppliers, fetchSuppliersWithKeyword }
