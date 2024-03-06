import axios from "./axios"

const fetchAllStorages = (page) => {
    return axios.get(`api/storage/get-storage?page=${page}`);
}


export { fetchAllStorages }