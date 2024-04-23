import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '1m', target: 10 },    // Ramp up to 10 users over 1 minute
        { duration: '3m', target: 10 },    // Stay at 10 users for 3 minutes
        { duration: '1m', target: 50 },    // Ramp up to 50 users over 1 minute
        { duration: '3m', target: 50 },    // Stay at 50 users for 3 minutes
        { duration: '1m', target: 0 },     // Ramp down to 0 users over 1 minute
    ],
};

const BASE_URL = 'http://localhost:5000';
const ENDPOINT = '/conversion/money';

export default function () {
    let amount = Math.random() * 100;
    let fromCurrency = 'USD';
    let toCurrency = 'EUR';

    let res = http.get(`${BASE_URL}${ENDPOINT}?amount=${amount}&fromCurrency=${fromCurrency}&toCurrency=${toCurrency}`);

    check(res, {
        'status is 200': (r) => r.status === 200,
        'response is a number': (r) => {
            let responseValue = parseFloat(r.body);
            return !isNaN(responseValue);
        },
    });

    sleep(1);
}
