import { useState, useEffect } from "react";
import { Row, Col, Dropdown } from "react-bootstrap";
import { fetchAllCategories } from "~/services/CategoryServices";
import { CustomToggle, CustomMenu } from "../components/others/Dropdown";

const RowDataImportOrder = ({ onChange }) => {
    const [storageName, setStorageName] = useState('');
    const [storageAddress, setStorageAddress] = useState('');


    const [totalCategories, setTotalCategories] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [selectedCategoryId, setSelectedCategoryId] = useState(null);



    useEffect(() => {
        getAllCategories();
    }, [])

    useEffect(() => {
        onChange({ aaa: storageName, z: storageAddress, selectedCategoryId: selectedCategoryId })
    }, [selectedCategoryId, storageName, storageAddress])


    const getAllCategories = async () => {
        let res = await fetchAllCategories();
        setTotalCategories(res);
    }

    const handleCategoryClick = (category, event) => {
        console.log(event);
        setSelectedCategory(category.categoryName);
        setSelectedCategoryId(category.categoryId);
    }

    const handleChangeAddress = (event) => {
        setStorageAddress(event.target.value);
    }

    const handleChangeName = (event) => {
        setStorageName(event.target.value);
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
                <input type="text" className="form-control inputCSS" value={storageAddress} onChange={handleChangeAddress} />
            </div>
        </Col>
        <Col md={2}>
            <div className="form-group mb-3">
                <label >Mã hàng hóa</label>
                <input type="text" className="form-control inputCSS" value={storageName} onChange={(event) => handleChangeName(event)} />
            </div>
        </Col>



    </Row>)
}


export default RowDataImportOrder