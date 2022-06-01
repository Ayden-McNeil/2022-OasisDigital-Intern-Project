import firebase_admin
from firebase_admin import credentials, storage
import os
import sys
from uuid import uuid4

keyFilePath = sys.argv[2]

cred = credentials.Certificate(keyFilePath)
firebase_admin.initialize_app(cred, {
    'storageBucket': 'oasis-unity-project.appspot.com'
})

bucket = storage.bucket()

branch = sys.argv[1]


def fileUploader(directory):
    for filename in os.listdir(directory):
        f = os.path.join(directory, filename)
        if os.path.isfile(f):
            blob = bucket.blob(branch + "/" + f)

            accessToken = uuid4()
            metadata = {"firebaseStorageDownloadTokens": accessToken}
            blob.metadata = metadata

            blob.upload_from_filename(f)
            blob.make_public()

            if filename == "index.html":
                file = open("url.txt", "a")
                file.write(blob.public_url)
                file.close()
        else:
            fileUploader(f)


fileUploader("WebGL")
