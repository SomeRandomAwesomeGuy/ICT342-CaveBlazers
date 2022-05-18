import os

import numpy as np
from PIL import Image
from equilib import cube2equi
from ISR.models import RDN

"""
 @software{pyequilib2021github,
  author = {Haruya Ishikawa},
  title = {PyEquilib: Processing Equirectangular Images with Python},
  url = {http://github.com/haruishi43/equilib},
  version = {0.5.0},
  year = {2021},
 }
"""


def load_image(image):
    target_image = Image.open(image)
    target_image = np.asarray(target_image)
    target_image = np.transpose(target_image, (2, 0, 1))
    return target_image

def save_image(image, path):
    image.save(path)

def cubemap_to_equirectangular(image, format):
    # Converts the cubemap into an equirectangular
    return cube2equi(cubemap=image,
                     height=30735,
                     width=3072,
                     cube_format=format,
                     )

def crop_equirectangular(image):
    # Crops image in line
    width, height = image.size
    image = image.crop((0, height/2-width/20, width, height/2+width/20))

    return image
    # Crop equirectangular Images to the correct dimensions

def crop_rectilinear(image):
    width, height = image.size
    ratio = height/width

    return image

def ISR(image):
    rdn = RDN(weights='psnr-small')
    img = rdn.predict(image)
    img = Image.fromarray(img)
    return img


"""
Complete Panoramics
Step 1, Convert to equirectangular
Step 2, Crop to 10:1 aspect ratio
Step 3, Upscale image

"""
assets = os.listdir()

for filename in os.listdir("ICT342CaveProject/Import"):
    if filename not in assets:
        image = load_image(filename)
        width, height = image.size
        if width/height == 10:
            image = crop_equirectangular(image)
            image = ISR(image)
            save_image(image, "ICT342CaveProject/Assets/Resources/Displays")
        if width/height == 4/3:
            image = cubemap_to_equirectangular(image, "dice")
            image = crop_equirectangular(image)
            image = ISR(image)
            save_image(image, "ICT342CaveProject/Assets/Resources/Displays")
        if width/height == 6/1:
            image = cubemap_to_equirectangular(image, "horizon")
            image = crop_equirectangular(image)
            image = ISR(image)
            save_image(image, "ICT342CaveProject/Assets/Resources/Displays")
        if width / height == 1 / 6:
            image = cubemap_to_equirectangular(image, "")
            image = crop_equirectangular(image)
            image = ISR(image)
            save_image(image, "ICT342CaveProject/Assets/Resources/Displays")

