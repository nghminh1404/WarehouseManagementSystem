import { useEffect, useState } from "react";
import { Modal, Button } from "react-bootstrap"
import { toast } from 'react-toastify';
import { createNewStorage } from "~/services/StorageServices";
import { validatePhone, validateText, validateTextRequired } from "~/validate";

const ModelAddStorage = ({ isShow, handleClose, updateTableStorage }) => {
    const [storageName, setStorageName] = useState("");
    const [storageAddress, setStorageAddress] = useState("");
    const [storagePhone, setStoragePhone] = useState("");


    const handleSave = async () => {
        if (!validatePhone.test(storagePhone)) {
            toast.error("Định dạng số điện thoại sai");
        } else if (!validateTextRequired.test(storageName)) {
            toast.error("Tên khống được trống và chứa ký tự đặc biệt");
        } else if (!validateText.test(storageAddress)) {
            toast.error("Địa chỉ không được chứa ký tự đặc biệt");
        }
        else {
            let res = await createNewStorage(storageName, storageAddress, storagePhone);
            toast.success("Thêm kho hàng", {
                className: 'toast-success',

            });
            handleReset();
            updateTableStorage();
            handleClose();
        }

    };

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
        <Modal show={isShow} onHide={handleCloseModal}>
            <Modal.Header closeButton>
                <Modal.Title>Thêm kho hàng</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="body-add-new">
                    <div className="form-group mb-3">
                        <label >Tên Kho hàng</label>
                        <input type="text" className="form-control inputCSS" required aria-describedby="emailHelp" value={storageName} onChange={(event) => setStorageName(event.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Địa chỉ</label>
                        <input type="text" className="form-control inputCSS" value={storageAddress} onChange={(event) => setStorageAddress(event.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label >Số điện thoại nhà cung cấp</label>
                        <input type="text" className="form-control inputCSS" placeholder="0123xxx" value={storagePhone} onChange={(event) => setStoragePhone(event.target.value)} />
                    </div>


                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleReset}>
                    Xóa thông tin thay đổi
                </Button>
                <Button variant="secondary" onClick={handleCloseModal}>
                    Đóng
                </Button>
                <Button variant="primary" className="ButtonCSS" onClick={handleSave}>
                    Lưu
                </Button>
            </Modal.Footer>
        </Modal>
    </>)
}

export default ModelAddStorage;