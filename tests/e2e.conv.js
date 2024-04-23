
import { Selector } from 'testcafe';

fixture`ConversionController End-to-End Test`
    .page`http://localhost:5000`
   


test('Should convert currency successfully', async t => {
    await t
        .navigateTo('/conversion/money?amount=80&fromCurrency=USD&toCurrency=EUR');
    
    await t
        .expect(Selector('status-code').innerText).eql('200');
    
    await t
        .expect(Selector('response-body').innerText).contains('74.4');
    
    await t
        .expect(/^[0-9.]+$/.test(Selector('response-body').innerText)).ok();
    
});

