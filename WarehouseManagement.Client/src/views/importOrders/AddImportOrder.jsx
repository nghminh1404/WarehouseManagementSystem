import { useEffect, useState } from "react";
import React from 'react';
import { Modal, Button, Row, Col, DropdownButton, Dropdown } from "react-bootstrap"
import { CustomToggle, CustomMenu } from '../components/others/Dropdown';
import { fetchAllSuppliers } from '~/services/SupplierServices';
import { fetchAllCategories } from "~/services/CategoryServices";
import { fetchAllStorages } from '~/services/StorageServices';
import { addNewImportOrder } from "~/services/ImportOrderServices";

import RowDataImportOrder from "./RowDataImport";

const ModelAddImportOrder = ({ isShow, handleClose }) => {


    const [totalStorages, setTotalStorages] = useState([]);
    const [selectedStorage, setSelectedStorage] = useState(null);
    const [selectedStorageId, setSelectedStorageId] = useState(null);



    const [totalSuppliers, setTotalSuppliers] = useState([]);
    const [selectedSupplier, setSelectedSupplier] = useState(null);
    const [selectedSupplierId, setSelectedSupplierId] = useState(null);

    const [rowsData, setRowsData] = useState([]);
    const [dataImportOrder, setDataImportOrder] = useState([]);

    useEffect(() => {
        getAllStorages();
        getAllSuppliers();
    }, [])

    const getAllStorages = async () => {
        let res = await fetchAllStorages();
        setTotalStorages(res);
    }


    const handleStorageClick = (storage) => {
        setSelectedStorage(storage.storageName);
        setSelectedStorageId(storage.storageId);
    }


    const getAllSuppliers = async () => {
        let res = await fetchAllSuppliers();
        setTotalSuppliers(res);
    }

    const handleSupplierClick = (supplier, event) => {
        setSelectedSupplier(supplier.supplierName);
        setSelectedSupplierId(supplier.supplierId)
    }




    const handleReset = () => {
        setRowsData([]);
    }

    const handleCloseModal = () => {
        handleReset();
        handleClose();
    }

    const addRowDataImportOrder = (index, importData) => {
        const updateDataImport = [...rowsData];
        updateDataImport[index] = importData;
        setRowsData(updateDataImport);
    }

    const renderImportData = () => {
        return rowsData.map((data, index) => (
            <RowDataImportOrder key={index} onChange={(importData) => addRowDataImportOrder(index, importData)} />
        ))
    }

    const handleAddImportOrder = async () => {
        let res = await addNewImportOrder(1, selectedSupplierId, 200000, "", "2024-03-23T07:11:43.161Z", "2024-03-23T07:11:43.161Z", 1, "", selectedStorageId, 1, 1, "", 1);
        console.log(res);
        handleCloseModal();
    }






    return (<>
        <Modal show={isShow} onHide={handleCloseModal} size="lg">
            <Modal.Header closeButton>
                <Modal.Title>Thêm lô hàng nhập</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <Row style={{ marginBottom: '20px' }}>
                        <Col md={3}>
                            <DropdownButton className="DropdownButtonCSS" title={selectedStorage !== null ? selectedStorage : "Tất cả Kho"} variant="success" style={{ zIndex: 9999 }}>
                                {totalStorages && totalStorages.length > 0 && totalStorages.map((c, index) => (
                                    <Dropdown.Item key={`storage ${index}`} eventKey={c.storageName} onClick={(e) => handleStorageClick(c, e)}>{c.storageName}</Dropdown.Item>
                                ))}
                            </DropdownButton>
                        </Col>

                        <Col md={3}>
                            <div className="align-middle text-nowrap" style={{ overflow: 'visible' }}>
                                <Dropdown style={{ position: 'relative' }}>
                                    <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                                        <span style={{ color: 'white' }}>{selectedSupplier !== null ? selectedSupplier : "Nhà cung cấp"}</span>
                                    </Dropdown.Toggle>

                                    <Dropdown.Menu as={CustomMenu} style={{ position: 'absolute', zIndex: '9999' }}>
                                        {totalSuppliers && totalSuppliers.length > 0 && totalSuppliers.map((s, index) => (
                                            <Dropdown.Item key={`supplier ${index}`} eventKey={s.supplierName} onClick={(e) => handleSupplierClick(s, e)}>
                                                {s.supplierName}
                                            </Dropdown.Item>
                                        ))}
                                    </Dropdown.Menu>
                                </Dropdown>
                            </div>
                        </Col>

                        <Col md={3}>
                            <div className="ButtonCSSDropdown">
                                <button
                                    className="btn btn-success border-left-0 rounded"
                                    type="button"
                                    onClick={() => setRowsData([...rowsData, {}])}
                                ><i className="fa-solid fa-plus"></i>
                                    &nbsp;
                                    Thêm sản phẩm
                                </button>
                            </div>
                        </Col>



                    </Row>

                    {renderImportData()}
                    <button onClick={() => console.log(rowsData)}>xem duwx lieu</button>





                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleReset}>
                    Xóa thông tin thay đổi
                </Button>
                <Button variant="primary" className="ButtonCSS" onClick={handleAddImportOrder}>
                    Lưu
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelAddImportOrder;