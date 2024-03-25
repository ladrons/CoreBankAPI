# Basit Banka API Projesi
Bu proje, C# kullanılarak geliştirilmiş basit bir banka ödeme API'sini içerir. Proje, ödeme işlemlerini ele almak için bir API sağlar. Kullanıcılar, ödeme yapmak için bu API'yi kullanabilirler.

## Başlarken
Bu adımlar, projeyi yerel makinenizde çalıştırmak için yapmanız gereken işlemleri anlatır.

### Gereksinimler
Bu projeyi çalıştırabilmek için aşağıdaki yazılımların yüklü olduğundan emin olun:

- .NET Core SDK
- Git 2.44.0 veya üstü
- Bir C# IDE (Visual Studio Code, Visual Studio)

### Kurulum
1. Projeyi kendi bilgisayarınıza klonlayın: (Terminal ya da Visual Studio da bulunan Clona A Repository özelliği ile)

    ```sh
    git clone https://github.com/ladrons/CoreBankAPI.git
    ```

2. Gerekli paketler için projenin bulunduğu dizinde aşağıdaki kodu çalıştırın: (Terminal ya da Developer Command Prompt kullanarak)

    ```sh
    dotnet restore
    ```

3. Visual Studio ya da farklı bir IDE üzerinden Start butonu üzerinden veya F5 tuşu ile projeyi çalıştırın.

## Kullanım
Bu API, basit bir HTTP isteği ile kullanılabilir. Örnek bir istek: (Swagger ya da PostMan üzerinden yapılabilir)

### Örnek Ödeme İsteği

```json
    POST /api/Payment/ReceivePayment
    Content-Type: application/json

    {
    "cardUsername": "John Doe",
    "cardNumber": "110",
    "expirationMonth": "12",
    "expirationYear": "25",
    "securityNumber": "123",
    "amount": 179,99
    }
```
    
Bu istek, ödeme işlemini gerçekleştirmek için API'ye bir ödeme bilgisi gönderir. İsteğin Content-Type başlığı application/json olarak ayarlanmıştır ve istek gövdesinde JSON formatında ödeme bilgileri bulunmaktadır. Bu bilgiler arasında kart numarası, son kullanma ayı ve yılı, CVV (güvenlik kodu) ve ödeme miktarı yer almaktadır.

### Bu API projesini kullanan diğer projelerim
https://github.com/ladrons/SolanisHotel (Gerekiyorsa URL bilgisi güncellenmelidir)

## Lisans

Bu proje MIT Lisence ile lisanslanmıştır.

## İletişim

Soru ve önerileriniz için bana burak_cevik76@hotmail.com.tr veya https://www.linkedin.com/in/burakcevik76/ adreslerinden ulaşabilirsiniz.
