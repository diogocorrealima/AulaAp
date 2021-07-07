import axios from 'axios';

const url = 'http://localhost:3000/Orders'
export default class OrderAPI {
  getOrderByOrderCode = async (orderCode: string) => {

    return await axios.get(`${url}/${orderCode}`).then(result => result.data).catch((err) => err.response);
    // return await axios(config).then(result => result.data).catch((err) => err.response);
  };
}

