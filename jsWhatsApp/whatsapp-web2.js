// const {
//     Client
// } = require('whatsapp-web.js');
// const client =
//     new Client({
//         puppeteer: {
//             args: ['--no-sandbox'],
//         }
//     });

// client.on('qr', (qr) => {
//     console.log('QR RECEIVED', qr);
// });

// client.on('ready', () => {
//     console.log('Client is ready!');
// });

// client.initialize();


const qrcode = require('qrcode-terminal');

const {
    Client
} = require('whatsapp-web.js');
const client = new Client();

client.on('qr', qr => {
    qrcode.generate(qr, {
        small: true
    });
});

client.on('ready', () => {
    console.log('Client is ready!');
});

client.on('message', message => {
    var contact = message.getContact();
    if (contact.IsMyContact) {
        message.reply(contact.getAbout());
        message.reply("Não posso falar no momento 😞");
    } else {
        contact.block()
    }
    // if (message.body.includes("Amor") || message.body.includes("noite")) {
    //     message.reply("Valor do Atendimento??");
    // }
});

client.initialize();