window.webCamera = {
    getPhoto: async () => {
        try {
            // Minta izin akses video
            const stream = await navigator.mediaDevices.getUserMedia({ video: true });

            // Buat elemen video virtual (tidak ditampilkan di UI) untuk menangkap stream
            const video = document.createElement('video');
            video.srcObject = stream;
            await video.play();

            // Tunggu sebentar agar kamera fokus dan stabil
            await new Promise(r => setTimeout(r, 500));

            // Buat elemen canvas untuk "menggambar" frame video saat ini (capture)
            const canvas = document.createElement('canvas');
            canvas.width = video.videoWidth;
            canvas.height = video.videoHeight;
            canvas.getContext('2d').drawImage(video, 0, 0);

            // Matikan kamera segera setelah foto diambil
            stream.getTracks().forEach(t => t.stop());

            // Kembalikan gambar dalam format Base64 string
            return canvas.toDataURL('image/jpeg');
        } catch (error) {
            console.error("Error accessing camera: ", error);
            return null;
        }
    }
};