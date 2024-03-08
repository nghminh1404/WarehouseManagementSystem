import { useEffect, useState } from "react";
import { Modal, Button } from "react-bootstrap"
import { toast } from 'react-toastify';
import { EditStorage } from "~/services/StorageServices";


const ModelEditStorage = ({ isShow, handleClose, dataUpdateStorage, updateTableStorage }) => {
    const [storageName, setStorageName] = useState("");
    const [storageAddress, setStorageAddress] = useState("");
    useEffect(() => {
        if (isShow) {
            setStorageName(dataUpdateStorage.storageName);
            setStorageAddress(dataUpdateStorage.storageAddress);
        }
    }, [dataUpdateStorage])
    const handleSave = async () => {
        let res = await EditStorage(dataUpdateStorage.storageId, storageName, storageAddress);
        toast.success("Sửa thông tin nhà cung cấp thành công", {
            className: 'toast-success',
        });
        updateTableStorage();
        handleClose();
    }

    return (<>
        <Modal show={isShow} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Sửa thông tin nhà cung cấp</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <div className="form-group mb-3">
                        <label >Tên kho hàng</label>
                        <input type="text" className="form-control inputCSS" aria-describedby="emailHelp" placeholder="Tên kho hàng" value={storageName} onChange={(event) => setStorageName(event.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Địa chỉ</label>
                        <input type="text" className="form-control inputCSS" placeholder="Địa chỉ" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                    </div>



                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Đóng
                </Button>
                <Button variant="primary" className="ButtonCSS" onClick={handleSave}>
                    Lưu thay đổi
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelEditStorage;