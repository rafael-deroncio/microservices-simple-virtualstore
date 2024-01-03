async function submitForm() {
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    var loginData = {
        username: username,
        password: password
    };

    try {
        var response = await fetch('URL_DA_SUA_API_DE_LOGIN', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
                // Adicione outros headers conforme necessário
            },
            body: JSON.stringify(loginData)
        });

        if (response.ok) {
            document.getElementById('errorMessage').innerText = '';
            alert('Login successful!');
            // Você pode redirecionar o usuário ou realizar outras ações após o login bem-sucedido
        } else {
            var errorData = await response.json();
            document.getElementById('errorMessage').innerText = errorData.message || 'Erro de autenticação';
        }
    } catch (error) {
        console.error('Erro durante a solicitação de login:', error);
        document.getElementById('errorMessage').innerText = 'Erro durante a solicitação de login';
    }
}
