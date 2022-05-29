import numpy as np
import ISR
from ISR.models import RDN
from PIL import Image
from equilib.cube2equi.base import cube2equi
from py360convert import e2c


import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'


def load_image(image):
    target_image = Image.open(image)
    return target_image


def save_image(image, path):
    image.save(path)


def cubemap_to_equirectangular(image):
    # Converts the cubemap into an equirectangular
    width = image.width
    height = int(width * (3 / 4))

    image = np.asarray(image)
    image = cube2equi(cubemap=image,
                      width=width,
                      height=height,
                      cube_format="horizon",
                      )
    return Image.fromarray(image)


def equirectangular_to_cubemap(image):
    width = image.width
    height = int(width * (3 / 4))
    rots = {
        'roll': 0.,
        'pitch': np.pi / 4,
        'yaw': np.pi / 4,
    }

    image = np.asarray(image)

    image = e2c(e_img=image,
                face_w=int(width/4),
                cube_format="dice",
                mode="bilinear")

    image = Image.fromarray(image)

    return image


def crop_equirectangular(image):
    # Crops image in line
    width, height = image.size
    image = image.crop((0, height / 2 - width / 20, width, height / 2 + width / 20))

    return image
    # Crop equirectangular Images to the correct dimensions


def crop_rectilinear(image):
    width, height = image.size
    ratio = height / width

    return image


def isr(image):
    image = np.array(image)
    rdn = RDN(weights='psnr-small')
    image = rdn.predict(image, by_patch_of_size=50)
    image = Image.fromarray(image)

    return image


def main():
    filelist = os.listdir(os.getcwd() + "\\Assets\\Resources\\Displays")
    for file in os.listdir(os.getcwd() + "\\Import"):
        if file not in filelist:
            image = load_image(os.getcwd() + "\\Import\\" + file)
            ratio = image.width / image.height

            if ratio == 2:
                image = equirectangular_to_cubemap(image)
                image = crop_equirectangular(image)
                image = isr(image)
                save_image(image, os.getcwd() + "\\Assets\\Resources\\Displays\\" + "2" + file)

            elif ratio == 4 / 3:
                image = crop_equirectangular(image)
                image = isr(image)
                save_image(image, os.getcwd() + "\\Assets\\Resources\\Displays\\" + "2" +   file)

            else:
                image = isr(image)

if __name__ == '__main__':
    main()
