const validatePhone = /(84|0[3|5|7|8|9])+([0-9]{8})/;

const validateTextRequired = /^[a-zA-Z0-9\sÀ-ÿ\u00C0-\u1EF9đĐ]+$/;

const validateText = /^[a-zA-Z0-9\s,.À-ÿ\u00C0-\u1EF9dĐ]*$/;

const validateEmail = /^(?:[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})?$/;

const removeWhiteSpace = (x) => { return x.trim().replace(/\s+/g, ' ') };

export { validatePhone, validateTextRequired, validateText, validateEmail, removeWhiteSpace };