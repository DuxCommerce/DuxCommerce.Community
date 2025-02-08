window.displayPaymentForm = async function (publishableKey, clientSecret, token) {
    const stripe = Stripe(publishableKey);
    const elements = stripe.elements({clientSecret});

    const paymentElement = elements.create('payment');
    paymentElement.mount('#payment-element');

    const form = document.getElementById('payment-form');

    let createdOrderId = null;

    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        let message = 'An error occurred before Stripe payment is finalized.';

        if (!createdOrderId) {
            const orderCreated = await fetch('/Stripe/CreateOrder', {
                    method: "POST",
                    credentials: 'same-origin',
                    headers: { "RequestVerificationToken": token }
                })
                .then(response => {
                    if (!response.ok) {
                        throw new Error(message)
                    }

                    return response.json();
                })
                .catch(err => {
                    // Todo: handle the exception
                    console.log(err);
                });

            if (orderCreated) {
                const {orderId} = orderCreated
                createdOrderId = orderId;
            }
        }

        if (createdOrderId) {
            const {error} = await stripe.confirmPayment({
                elements, confirmParams: {
                    return_url: window.location.origin + '/Checkout/Confirmation?OrderId=' + createdOrderId
                }
            });

            message = error?.message;
        }

        if (message) {
            const errorMessage = document.getElementById('error-message')
            errorMessage.innerText = message
        }
    })
};