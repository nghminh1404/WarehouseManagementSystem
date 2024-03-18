import { useEffect, useState } from "react";
import { Modal, Button, Row, Col, DropdownButton, Dropdown } from "react-bootstrap"
import { toast } from 'react-toastify';
import { CustomToggle, CustomMenu } from '../components/others/Dropdown';
import { fetchAllSuppliers } from '~/services/SupplierServices';


import { fetchAllStorages } from '~/services/StorageServices';

const ModelAddImportOrder = ({ isShow, handleClose }) => {
    const [storageName, setStorageName] = useState("");
    const [storageAddress, setStorageAddress] = useState("");
    const [storagePhone, setStoragePhone] = useState("");

    const [totalStorages, setTotalStorages] = useState([]);
    const [selectedStorage, setSelectedStorage] = useState(null);
    const [selectedStorageId, setSelectedStorageId] = useState(null);

    const [totalSuppliers, setTotalSuppliers] = useState([]);
    const [selectedSupplier, setSelectedSupplier] = useState(null);
    const [selectedSupplierId, setSelectedSupplierId] = useState(null);

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
        setStorageName("");
        setStoragePhone("");
        setStorageAddress("");
    }

    const handleCloseModal = () => {
        handleReset();
        handleClose();
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

                    </Row>
                    <Row>
                        <Col md={3}>
                            <div className="form-group mb-3">
                                <label >Tên Kho hàng</label>
                                <input type="text" className="form-control inputCSS" required aria-describedby="emailHelp" value={storageName} onChange={(event) => setStorageName(event.target.value)} />
                            </div>
                        </Col>
                        <Col md={3}>
                            <div className="form-group mb-3">
                                <label >Địa chỉ</label>
                                <input type="text" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                            </div>
                        </Col>
                        <Col md={3}>
                            <div className="form-group mb-3">
                                <label >Địa chỉ</label>
                                <input type="text" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                            </div>
                        </Col>
                        <Col md={3}>
                            <div className="form-group mb-3">
                                <label >Địa chỉ</label>
                                <input type="text" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                            </div>
                        </Col>

                    </Row>





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