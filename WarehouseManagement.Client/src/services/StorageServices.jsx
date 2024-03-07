import axios from "./axios"

const fetchAllStorages = (page) => {
    return axios.get(`api/storage/get-storage?page=${page}`);
}

const createNewStorage = (storageName, storageAddress) => {
    return axios.post(`api/storage/add-storage`, { storageName, storageAddress });
}

const EditStorage = (storageId, storageName, storageAddress) => {
    return axios.put(`api/storage/update-storage`, { storageId, storageName, storageAddress });
}


export { fetchAllStorages, createNewStorage, EditStorage }