import axios from "./axios";

const addNewImportOrder = (userId, supplierId, totalCost, note, createdDate, importedDate, statusId, importCode, storageId, projectId, deliveryId, image, stokekeeperId) => {
    return axios.post(`api/ImportOrder/add-import-order`, { userId, supplierId, totalCost, note, createdDate, importedDate, statusId, importCode, storageId, projectId, deliveryId, image, stokekeeperId })
}

const fetchImportOrderNewest = () => {
    return axios.get(`api/ImportOrder/get-newest-import-order`);
}

const fetchImportOrdersWithfilter = (page, keyword, user, storage, project, storekeeper, status) => {
    return axios.get(`api/ImportOrder/get-import-orders?page=${page}${keyword ? `&keyword=${keyword}` : ''}${user ? `&user=${user}` : ''}${storage ? `&storage=${storage}` : ''}${project ? `&project=${project}` : ''}${storekeeper ? `&storekeeper=${storekeeper}` : ''}${status ? `&status=${status}` : ''}`);
}

export { addNewImportOrder, fetchImportOrderNewest, fetchImportOrdersWithfilter }