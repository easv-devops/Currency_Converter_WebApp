/*

import {Selector} from 'testcafe';

fixture`HistoryController End-to-End Test`
    .page`http://144.91.75.24:5001/`
    

test('Should fetch conversion history successfully', async t => {

    await t
        .navigateTo('/conversion/history');
    await t
        .expect(Selector('status-code').innerText).eql('200');
    await t
        .expect(Selector('response-message').innerText).contains('Conversion history fetched successfully');

    const responseData = await Selector('response-data').innerText;
    const responseJson = JSON.parse(responseData);
    const conversionHistory = responseJson.responseData;

    await t
        .expect(conversionHistory.length).gt(0, 'At least one record should exist in the conversion history');

    for (const record of conversionHistory) {
        await t
            .expect(record).contains({
                sourceCurrency: 'USD',
                targetCurrency: 'EUR',
                amount: 100,
                convertedAmount: 83.50
            });

    }
});


*/
