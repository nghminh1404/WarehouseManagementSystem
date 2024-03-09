import axios from "./axios"

const fetchAllStorages = (page) => {
    return axios.get(`api/storage/get-storage?page=${page}`);
}

const fetchStoragesWithKeyword = (page, keyword) => {
    return axios.get(`api/storage/get-storage?page=${page}&keyword=${keyword}`)
}

const createNewStorage = (storageName, storageAddress, storagePhone) => {
    return axios.post(`api/storage/add-storage`, { storageName, storageAddress, storagePhone });
}

const EditStorage = (storageId, storageName, storageAddress, storagePhone) => {
    return axios.put(`api/storage/update-storage`, { storageId, storageName, storageAddress, storagePhone });
}


export { fetchAllStorages, fetchStoragesWithKeyword, createNewStorage, EditStorage }