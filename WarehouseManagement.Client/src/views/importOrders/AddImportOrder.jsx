import { useEffect, useState } from "react";
import React from 'react';
import { Modal, Button, Row, Col, DropdownButton, Dropdown } from "react-bootstrap"
import { CustomToggle, CustomMenu } from '../components/others/Dropdown';
import { fetchAllSuppliers } from '~/services/SupplierServices';
import { fetchAllStorages } from '~/services/StorageServices';
import { addNewImportOrder, fetchImportOrderNewest } from "~/services/ImportOrderServices";
import { createNewImportOrderDetail } from "~/services/ImportOrderDetailServices";
import { formatDateImport } from "~/validate";

import RowDataImportOrder from "./RowDataImport";
import { toast } from "react-toastify";

const ModelAddImportOrder = ({ isShow, handleClose, updateTable }) => {


    const [totalStorages, setTotalStorages] = useState([]);
    const [selectedStorage, setSelectedStorage] = useState(null);
    const [selectedStorageId, setSelectedStorageId] = useState(null);



    const [totalSuppliers, setTotalSuppliers] = useState([]);
    const [selectedSupplier, setSelectedSupplier] = useState(null);
    const [selectedSupplierId, setSelectedSupplierId] = useState(null);

    const [rowsData, setRowsData] = useState([]);

    const [totalPrice, setTotalPrice] = useState(0);
    const [price, setPrice] = useState([]);

    const [selectedDate, setSelectedDate] = useState('');

    useEffect(() => {
        getAllStorages();
        getAllSuppliers();
    }, [])

    useEffect(() => {
        setRowsData([]);
    }, [selectedStorageId, selectedSupplierId])


    useEffect(() => {
        setTotalPrice(0);

        price && price.length > 0 && (price.map((p, index) => {
            setTotalPrice(x => x + p);
        }))
    }, price)
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


    const handleDateChange = (event) => {
        setSelectedDate(event.target.value);
    };



    const handleReset = () => {
        setRowsData([]);
        setSelectedStorage(null);
        setSelectedStorageId(null);
        setSelectedSupplier(null);
        setSelectedSupplierId(null);
        setSelectedDate('');
        setPrice([]);
        setTotalPrice(0);
    }

    const handleCloseModal = () => {
        handleReset();
        handleClose();
    }

    const takeRowDataImportOrder = (index, importData) => {
        const updateDataImport = [...rowsData];
        updateDataImport[index] = importData;
        setRowsData(updateDataImport);

        const updatePrice = [...price];
        updatePrice[index] = importData.totalOneGoodPrice;
        setPrice(updatePrice);
    }

    const handleAddRowDataImport = () => {
        if (selectedStorageId && selectedSupplierId) {
            setRowsData([...rowsData, {}])
        } else {
            toast.info("Vui lòng điền kho hoặc nhà cung cấp")
        }
    }

    const renderImportData = () => {
        return rowsData.map((data, index) => (
            <RowDataImportOrder key={index} onChange={(importData) => takeRowDataImportOrder(index, importData)} selectedSupplierId={selectedSupplierId} selectedStorageId={selectedStorageId} />
        ))


    }

    const handleAddImportOrder = async () => {
        let res = await addNewImportOrder(1, selectedSupplierId, totalPrice, "", "2024-03-24T08:47:56.243Z", formatDateImport(selectedDate), 1, "", selectedStorageId, 1, 1, "", 1);
        let resImportId = await fetchImportOrderNewest();
        if (rowsData && rowsData.length > 0) {
            await Promise.all(rowsData.map(async (data, index) => {
                await createNewImportOrderDetail(resImportId, data.costPrice, data.goodsId, data.quantity);
            }));
        }
        toast.success("Thêm lô hàng nhập thành công");
        updateTable();
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
                            <div>
                                <input type="date" value={selectedDate} onChange={handleDateChange} />
                            </div>
                        </Col>

                        <Col md={3}>
                            <div className="ButtonCSSDropdown">
                                <button
                                    className="btn btn-success border-left-0 rounded"
                                    type="button"
                                    onClick={handleAddRowDataImport}
                                ><i className="fa-solid fa-plus"></i>
                                    &nbsp;
                                    Thêm sản phẩm
                                </button>
                            </div>
                        </Col>



                    </Row>

                    {renderImportData()}
                    <button>{totalPrice}</button>





                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="primary" className="ButtonCSS" onClick={handleAddImportOrder}>
                    Lưu
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelAddImportOrder;