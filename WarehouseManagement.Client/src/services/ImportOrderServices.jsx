import axios from "./axios";

const addNewImportOrder = (userId, supplierId, totalCost, note, createdDate, importedDate, statusId, importCode, storageId, projectId, deliveryId, image, stokekeeperId) => {
    return axios.post(`api/ImportOrder/add-import-order`, { userId, supplierId, totalCost, note, createdDate, importedDate, statusId, importCode, storageId, projectId, deliveryId, image, stokekeeperId })
}

const fetchImportOrderNewest = () => {
    return axios.get(`api/ImportOrder/get-newest-import-order`);
}

export { addNewImportOrder, fetchImportOrderNewest }