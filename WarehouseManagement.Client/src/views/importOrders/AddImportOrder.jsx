import { useEffect, useState } from "react";
import React from 'react';
import { Modal, Button, Row, Col, DropdownButton, Dropdown } from "react-bootstrap"
import { toast } from 'react-toastify';
import { CustomToggle, CustomMenu } from '../components/others/Dropdown';
import { fetchAllSuppliers } from '~/services/SupplierServices';
import { fetchAllCategories } from "~/services/CategoryServices";


import { fetchAllStorages } from '~/services/StorageServices';

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

    const addRowDataImportOrder = () => {
        setRowsData(rowsData => {
            const updatedRowsData = [...rowsData, <RowDataImportOrder />];
            return updatedRowsData;
        });

        console.log(dataImportOrder);

    }


    const RowDataImportOrder = () => {
        const [storageName, setStorageName] = useState("");
        const [storageAddress, setStorageAddress] = useState("");
        const [storagePhone, setStoragePhone] = useState("");


        const [totalCategories, setTotalCategories] = useState([]);
        const [selectedCategory, setSelectedCategory] = useState(null);
        const [selectedCategoryId, setSelectedCategoryId] = useState(null);

        const [dataRowImport, setDataRowImport] = useState({});


        useEffect(() => {
            getAllCategories();
        }, [])

        useEffect(() => {
            setDataRowImport({
                category: { selectedCategory }
            })

            setDataImportOrder([...dataImportOrder, dataRowImport]);
        }, [selectedCategory])

        const getAllCategories = async () => {
            let res = await fetchAllCategories();
            setTotalCategories(res);
        }

        const handleCategoryClick = (category, event) => {
            setSelectedCategory(category.categoryName);
            setSelectedCategoryId(category.categoryId);
        }

        return (<Row>
            <Col md={3}>
                <label>Danh mục</label>
                <div>
                    <Dropdown style={{ position: 'relative' }}>
                        <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                            <span style={{ color: 'white' }}>{selectedCategory !== null ? selectedCategory : "Danh mục"}</span>
                        </Dropdown.Toggle>

                        <Dropdown.Menu as={CustomMenu} style={{ position: 'absolute', zIndex: '9999' }}>
                            {totalCategories && totalCategories.length > 0 && totalCategories.map((c, index) => (
                                <Dropdown.Item key={`category ${index}`} eventKey={c.categoryName} onClick={(e) => handleCategoryClick(c, e)}>
                                    {c.categoryName}
                                </Dropdown.Item>
                            ))}
                        </Dropdown.Menu>
                    </Dropdown>

                </div>
            </Col>
            <Col md={2}>
                <div className="form-group mb-3">
                    <label >Tên hàng hóa</label>
                    <input type="text" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                </div>
            </Col>
            <Col md={2}>
                <div className="form-group mb-3">
                    <label >Mã hàng hóa</label>
                    <input type="text" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                </div>
            </Col>
            <Col md={2}>
                <div className="form-group mb-3">
                    <label >Số lượng</label>
                    <input type="number" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                </div>
            </Col>

            <Col md={2}>
                <div className="form-group mb-3">
                    <label >Hạn bảo hành</label>
                    <input type="date" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                </div>
            </Col>



        </Row>)
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
                                    onClick={addRowDataImportOrder}
                                ><i className="fa-solid fa-plus"></i>
                                    &nbsp;
                                    Thêm sản phẩm
                                </button>
                            </div>
                        </Col>



                    </Row>

                    {rowsData.map((row, index) => (
                        <div key={`rowData${index}`}>
                            {row && React.isValidElement(row) ? React.cloneElement(row, {
                            }) : null}
                        </div>
                    ))}





                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleReset}>
                    Xóa thông tin thay đổi
                </Button>
                <Button variant="primary" className="ButtonCSS">
                    Lưu
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelAddImportOrder;